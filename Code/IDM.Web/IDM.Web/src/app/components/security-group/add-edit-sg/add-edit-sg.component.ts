import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Constant } from 'src/app/commons/constant.model';
import { SaveSecurityGroupRequest } from 'src/app/models/requests/save-security-group-request.model';
import { SecurityGroupDTO } from 'src/app/models/security-group-dto.model';
import { APIService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-sg',
  templateUrl: './add-edit-sg.component.html',
  styleUrls: ['./add-edit-sg.component.css']
})
export class AddEditSGComponent implements OnInit {

  @Input() sgInfo:SecurityGroupDTO;
  currentSGInfo:SecurityGroupDTO;

  isAdd:boolean;
  errors:any[] = [];

  constructor(private api:APIService) { }

  ngOnInit(): void {
    //Check if the transaction is a Add or Edit Security Group
    this.isAdd = this.sgInfo.internalID == Constant.GUID_EMPTY;
    //Store sgInfo in currentSGInfo
    this.currentSGInfo = this.sgInfo;
    //Populate DisplayName layers
    this.populateLayers();
  }
  
  populateLayers() {
    if(this.currentSGInfo.displayName === Constant.STRING_EMPTY)
      return;

    let splittedDisplayName = this.currentSGInfo.displayName.split(Constant.SLASH);
    for(let idx = 0; idx < splittedDisplayName.length; idx++){
      this.setInputValue("txtLayer" + [idx+1] , splittedDisplayName[idx]);
    }
  }

  setInputValue(inputID:string, value:string){
    let input = document.getElementById(inputID) as HTMLInputElement;
    if(input === undefined || input === null)
      return;
      
    input.value = value;
  }

  changeLayersValue(){
    let inputLayers = document.getElementsByName("layer"); 
    if(inputLayers == null || inputLayers.length == 0) 
      return;

    inputLayers.forEach((layer) => {
      let input = layer as HTMLInputElement;
      if(input === undefined || input === null)
        return;

      if(input.id === "txtLayer1") {
        this.currentSGInfo.displayName = input.value;
        return;
      }

      if(input.value === Constant.STRING_EMPTY)
        return;

      this.currentSGInfo.displayName += Constant.SLASH + input.value;
    })
    
    //Change aliasName if the transaction is Add
    if(this.isAdd)
      this.currentSGInfo.aliasName = this.currentSGInfo.displayName.split(Constant.SLASH).join(Constant.DASH).toLowerCase();
  }

  changeTypeValue(value:number){
    let isInternal = value == 0;

    let input = document.getElementById("txtLayer1") as HTMLInputElement;
    if(input === undefined || input === null)
      return;

    input.value = isInternal ? Constant.STRING_EMPTY : "Partner";
    input.disabled = !isInternal;
    this.changeLayersValue();
    this.currentSGInfo.type = value;
  }

  saveSG() {
    this.errors = [];
    let model = new SaveSecurityGroupRequest();
    model.functionID = "01A01";
    model.requestStatus = "A2";
    model.inputSG = this.currentSGInfo;

    //Save security group in database using API
    this.api.saveSG(model).subscribe(
      (response:any) => {
        Swal.fire("Success","Customer saved successfully", "success")
        .then(() => {
          //If success reload page
          window.location.reload();
        })
      },
      (error:HttpErrorResponse) => {
        let response = error as HttpErrorResponse
        //System Errors
        if(response.error == undefined) {
          this.errors.push(response.message);
          console.log(this.errors);
          return;
        }

        //API Error Title
        if(response.error.length === 0) {
          this.errors.push(response.error.title);
          console.log(this.errors);
          return;
        }

        //API Error Validation
        this.errors.push(response.error.errors);
        console.log(this.errors);
      }
    );
  }

}
