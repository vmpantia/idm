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

  isAdd:boolean;
  errors:any[] = [];
  mailAddresses:string[] = [];
  @Input()id:string;
  currentSGInfo:SecurityGroupDTO;

  constructor(private api:APIService) { }

  ngOnInit(): void {
    //Check if the transaction is a Add or Edit Security Group
    this.isAdd = this.id == Constant.GUID_EMPTY;

    if(this.isAdd) {
      this.currentSGInfo = new SecurityGroupDTO();
    }
    else {
      this.api.getSGByID(this.id).subscribe(
        (response:any) => {
          this.currentSGInfo = response;
          //Populate DisplayName layers
          this.populateLayers();
        }
      )
    }
  }
  
  populateLayers() {
    if(this.currentSGInfo.displayName === Constant.STRING_EMPTY)
      return;

    let splittedDisplayName = this.currentSGInfo.displayName.split(Constant.SLASH);
    for(let idx = 0; idx < splittedDisplayName.length; idx++){
      this.setInputValue("txtLayer" + [idx+1] , splittedDisplayName[idx]);
    }
  }

  setInputValue(inputID:string, value:string) {
    let input = document.getElementById(inputID) as HTMLInputElement;
    if(input === undefined || input === null)
      return;
      
    input.value = value;
  }
  
  changePrimarySelection(isInput:boolean) {
    this.mailAddresses = [];
    let inputMailAddresses = document.getElementsByName("mailaddress"); 
    console.log(inputMailAddresses);

    if(inputMailAddresses == null || inputMailAddresses.length == 0) 
      return;

    inputMailAddresses.forEach((mail) => {
      let input = mail as HTMLInputElement;

      if(input.value === Constant.STRING_EMPTY)
        return;


      switch(input.id){
        case "txtIDMMailAddress":
          input.value = isInput ? input.value : this.currentSGInfo.aliasName;
          this.mailAddresses.push(input.value + Constant.IDM_DOMAIN);
          break;
        case "txtRegionalMailAddress":
          input.value = isInput ? input.value : this.currentSGInfo.aliasName;
          this.mailAddresses.push(input.value + Constant.PH_IDM_DOMAIN);
          break;
        default:
          this.mailAddresses.push(input.value);
      }
    })
  }

  changeLayersValue() {
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
    if(this.isAdd) {
      this.currentSGInfo.aliasName = this.currentSGInfo.displayName.split(Constant.SLASH).join(Constant.DASH).toLowerCase();
      this.currentSGInfo.idmMailAddress = this.currentSGInfo.aliasName;
      this.currentSGInfo.regionalMailAddress = this.currentSGInfo.aliasName;
    }
    this.changePrimarySelection(false);
  }

  changeTypeValue(value:number) {
    let isInternal = value == 0;

    let input = document.getElementById("txtLayer1") as HTMLInputElement;
    if(input === undefined || input === null)
      return;

    input.value = isInternal ? Constant.STRING_EMPTY : "Partner";
    input.disabled = !isInternal;
    this.changeLayersValue();
    this.currentSGInfo.type = value;
  }

  parseSG(input:SecurityGroupDTO) {
    let parsedInput = new SecurityGroupDTO();

    //SG Details
    parsedInput.internalID = input.internalID;
    parsedInput.aliasName = input.aliasName?.trim();
    parsedInput.displayName = input.displayName?.trim();
    parsedInput.type = input.type;

    //Ownership Details
    parsedInput.ownerInternalID = input.ownerInternalID;
    parsedInput.admin1InternalID = input.admin1InternalID;
    parsedInput.admin2InternalID = input.admin2InternalID;
    parsedInput.admin3InternalID = input.admin3InternalID;

    //Email Addresses
    parsedInput.primaryMailAddress = input.primaryMailAddress?.trim();
    parsedInput.idmMailAddress = input.idmMailAddress?.trim() + Constant.IDM_DOMAIN;
    parsedInput.regionalMailAddress = input.regionalMailAddress?.trim() + Constant.PH_IDM_DOMAIN;
    parsedInput.companyMailAddress1 = input.companyMailAddress1?.trim();
    parsedInput.companyMailAddress2 = input.companyMailAddress2?.trim();

    //Common
    parsedInput.status = input.status;
    parsedInput.createdDate = input.createdDate;
    parsedInput.modifiedDate = input.modifiedDate;
    return parsedInput;
  }

  saveSG() {
    this.errors = [];
    let model = new SaveSecurityGroupRequest();
    model.functionID = "01A01";
    model.requestStatus = "A2";
    model.inputSG = this.parseSG(this.currentSGInfo);

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
          return;
        }

        //API Error Title
        if(response.error.length === 0) {
          this.errors.push(response.error.title);
          return;
        }

        //API Error Validation
        this.errors.push(response.error.errors);
      }
    );
  }
}
