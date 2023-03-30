import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Constant } from 'src/app/commons/constant.model';
import { MailAddressDTO } from 'src/app/models/mail-address-dto.model';
import { SaveSecurityGroupRequest } from 'src/app/models/requests/save-security-group-request.model';
import { SecurityGroupDTO } from 'src/app/models/security-group-dto.model';
import { APIService } from 'src/app/services/api.service';
import { UtilityService } from 'src/app/services/utility.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-sg',
  templateUrl: './add-edit-sg.component.html',
  styleUrls: ['./add-edit-sg.component.css']
})
export class AddEditSGComponent implements OnInit {

  @Input()id:string;
  
  //Error Variables
  errorFields:any[] = [];
  errorMessage:any;
  
  currentSGInfo:SecurityGroupDTO = new SecurityGroupDTO();

  isAdd:boolean;

  constructor(private api:APIService, private utility:UtilityService) { }

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
          this.populateLayers();
          this.changeDisplayNameValue();
        }
      )
    }
  }

  changeTypeValue(value:number) {
    this.currentSGInfo.type = value
    this.changeDisplayNameValue();
  }
  
  populateLayers() {
    let defaultLayer = 4;
    if(this.currentSGInfo.displayName === Constant.STRING_EMPTY)
      return;

    let splittedDisplayName = this.currentSGInfo.displayName.split(Constant.SLASH);
    for(let idx = 0; idx < splittedDisplayName.length; idx++){
      if((idx + 1) > defaultLayer)
        this.setInputValue("txtDisplayName" + defaultLayer, Constant.SLASH + splittedDisplayName[idx]);
      else
        this.setInputValue("txtDisplayName" + [idx + 1], splittedDisplayName[idx]);
    }
  }

  setInputValue(inputID:string, value:string) {
    let input = document.getElementById(inputID) as HTMLInputElement;
    if(input === undefined || input === null)
      return;

    input.value += value;
  }

  changeDisplayNameValue() {
    this.createDisplayName();
    this.createAliasName();
  }

  joinDisplayName(){
    let newDisplayName = Constant.STRING_EMPTY;
    let inputLayers = document.getElementsByName("displayName"); 

    inputLayers.forEach((layer) => {
      let input = layer as HTMLInputElement;
      if(input.id === "txtDisplayName1") {
        newDisplayName = input.value;
        return;
      }

      if(input.value === Constant.STRING_EMPTY)
        return; 
      
      if(newDisplayName !== Constant.STRING_EMPTY)
        newDisplayName += Constant.SLASH;
      
      newDisplayName += input.value;
    })
    return newDisplayName;
  }
  
  createDisplayName(){
    let newDisplayName = this.joinDisplayName();
    this.currentSGInfo.displayName = this.currentSGInfo.type == 0 ? newDisplayName : "Partner" + Constant.SLASH + newDisplayName;
  }

  createAliasName(){
    if(this.isAdd)
      this.currentSGInfo.aliasName = this.currentSGInfo.displayName.split(Constant.SLASH).join(Constant.DASH).toLowerCase();
  }

  parseSG(input:SecurityGroupDTO) {
    let parsedInput = new SecurityGroupDTO();

    //SG Details
    parsedInput.internalID = input.internalID;
    parsedInput.aliasName = input.aliasName.trim();
    parsedInput.displayName = input.displayName.trim();
    parsedInput.type = input.type;
    parsedInput.typeDescription = this.utility.convertType(input.type);

    //Mail Addresses details
    parsedInput.mailAddresses = input.mailAddresses;

    //Ownership Details
    parsedInput.ownerInternalID = input.ownerInternalID;
    parsedInput.admin1InternalID = input.admin1InternalID;
    parsedInput.admin2InternalID = input.admin2InternalID;
    parsedInput.admin3InternalID = input.admin3InternalID;

    //Common
    parsedInput.status = input.status;
    parsedInput.statusDescription = this.utility.convertStatus(input.status);
    parsedInput.createdDate = input.createdDate;
    parsedInput.modifiedDate = input.modifiedDate;
    return parsedInput;
  }

  resetError(){
    this.errorFields = [];
    this.errorMessage = Constant.STRING_EMPTY;
  }

  saveSG() {
    this.resetError();
    let model = new SaveSecurityGroupRequest();
    model.functionID = this.isAdd ? "01A01" : "01C01";
    model.requestStatus = "A2";
    model.inputSG = this.parseSG(this.currentSGInfo);

    //Save security group in database using API
    this.api.saveSG(model).subscribe(
      (response:any) => {
        Swal.fire("Success","Security Group saved successfully", "success")
        .then(() => {
          //If success reload page
          window.location.reload();
        })
      },
      (error:HttpErrorResponse) => {
        let response = error as HttpErrorResponse
        //System Errors
        if(response.error == undefined)
          this.errorMessage = response.message;
        //API Unexpected Error
        else if (response.error.errors === undefined) 
          this.errorMessage = response.error;
        //API Validation Error
        else
          this.errorFields.push(response.error.errors);
      }
    );

  }

  //---------------- Mail Address Functionalities ----------------
  addMailAddress() {
    let newMail = new MailAddressDTO();
    this.currentSGInfo.mailAddresses.push(newMail);
    this.resetMailError();
  }
  
  deleteMailAddress(idx:number){
    this.currentSGInfo.mailAddresses.splice(idx, 1);
    this.resetMailError();
  }

  resetMailError(){
    let defaultNoOfMail = 4;

    if(this.errorFields.length === 0)
      return;

    for(let idx = 0; idx < defaultNoOfMail; idx++){
      this.errorFields[0]["inputSG.MailAddresses[" + idx + "].MailAddress"] = Constant.STRING_EMPTY;
    }
  }
}
