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

  @Input()id:string;
  
  errors:any[] = [];
  mailAddresses:string[] = [];
  currentSGInfo:SecurityGroupDTO = new SecurityGroupDTO();
  isAdd:boolean;

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
          //Remove the domain in mail addresses
          this.currentSGInfo.idmMailAddress = this.currentSGInfo.idmMailAddress.split("@")[0];
          this.currentSGInfo.regionalMailAddress = this.currentSGInfo.regionalMailAddress.split("@")[0];
          this.populateLayers();
          this.populatePrimaryMailSelection();
          this.changeTypeValue(this.currentSGInfo.type);
        }
      )
    }
  }

  changeTypeValue(value:number) {
    this.currentSGInfo.type = value
    this.changeLayersValue();
  }
  
  populateLayers() {
    let defaultLayer = 3;
    if(this.currentSGInfo.displayName === Constant.STRING_EMPTY)
      return;

    let splittedDisplayName = this.currentSGInfo.displayName.split(Constant.SLASH);
    for(let idx = 0; idx < splittedDisplayName.length; idx++){
      if((idx + 1) > defaultLayer)
        this.setInputValue("txtLayer" + defaultLayer, Constant.SLASH + splittedDisplayName[idx]);
      else
        this.setInputValue("txtLayer" + [idx + 1], splittedDisplayName[idx]);
    }
  }

  setInputValue(inputID:string, value:string) {
    let input = document.getElementById(inputID) as HTMLInputElement;
    if(input === undefined || input === null)
      return;

    input.value += value;
  }
  
  populatePrimaryMailSelection() {
    this.mailAddresses = [];
    if(this.currentSGInfo.idmMailAddress !== Constant.STRING_EMPTY)
      this.mailAddresses.push(this.currentSGInfo.idmMailAddress + Constant.IDM_DOMAIN);
      
    if(this.currentSGInfo.regionalMailAddress !== Constant.STRING_EMPTY)
      this.mailAddresses.push(this.currentSGInfo.regionalMailAddress + Constant.PH_IDM_DOMAIN);
      
    if(this.currentSGInfo.companyMailAddress1 !== Constant.STRING_EMPTY)
      this.mailAddresses.push(this.currentSGInfo.companyMailAddress1);

    if(this.currentSGInfo.companyMailAddress2 !== Constant.STRING_EMPTY)
      this.mailAddresses.push(this.currentSGInfo.companyMailAddress2);
  }

  changeLayersValue() {
    let newDisplayName = Constant.STRING_EMPTY;
    let inputLayers = document.getElementsByName("layer"); 
    if(inputLayers == null || inputLayers.length == 0) 
      return;

    inputLayers.forEach((layer) => {
      let input = layer as HTMLInputElement;
      if(input.id === "txtLayer1") {
        newDisplayName = input.value;
        return;
      }

      if(input.value === Constant.STRING_EMPTY)
        return;

      newDisplayName += Constant.SLASH + input.value;
    })

    //Change display name if the transaction is add or edit
    this.currentSGInfo.displayName = this.currentSGInfo.type == 0 ? newDisplayName : "Partner" + Constant.SLASH + newDisplayName;
    if(this.isAdd) {
      //Change alias name, IDM mail address, regional mail address if the transaction is Add
      this.currentSGInfo.aliasName = this.currentSGInfo.displayName.split(Constant.SLASH).join(Constant.DASH).toLowerCase();
      this.currentSGInfo.idmMailAddress = this.currentSGInfo.aliasName;
      this.currentSGInfo.regionalMailAddress = this.currentSGInfo.aliasName;
      this.populatePrimaryMailSelection();
    }
  }

  parseSG(input:SecurityGroupDTO) {
    let parsedInput = new SecurityGroupDTO();

    //SG Details
    parsedInput.internalID = input.internalID;
    parsedInput.aliasName = input.aliasName.trim();
    parsedInput.displayName = input.displayName.trim();
    parsedInput.type = input.type;

    //Ownership Details
    parsedInput.ownerInternalID = input.ownerInternalID;
    parsedInput.admin1InternalID = input.admin1InternalID;
    parsedInput.admin2InternalID = input.admin2InternalID;
    parsedInput.admin3InternalID = input.admin3InternalID;

    //Email Addresses
    parsedInput.primaryMailAddress = input.primaryMailAddress.trim();
    parsedInput.idmMailAddress = input.idmMailAddress == Constant.STRING_EMPTY ?  Constant.STRING_EMPTY : input.idmMailAddress.trim() + Constant.IDM_DOMAIN;
    parsedInput.regionalMailAddress = input.regionalMailAddress  == Constant.STRING_EMPTY ?  Constant.STRING_EMPTY : input.regionalMailAddress.trim() + Constant.PH_IDM_DOMAIN;
    parsedInput.companyMailAddress1 = input.companyMailAddress1.trim();
    parsedInput.companyMailAddress2 = input.companyMailAddress2.trim();

    //Common
    parsedInput.status = input.status;
    parsedInput.createdDate = input.createdDate;
    parsedInput.modifiedDate = input.modifiedDate;
    return parsedInput;
  }

  saveSG() {
    this.errors = [];
    let model = new SaveSecurityGroupRequest();
    model.functionID = this.isAdd ? "01A01" : "01C01";
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
