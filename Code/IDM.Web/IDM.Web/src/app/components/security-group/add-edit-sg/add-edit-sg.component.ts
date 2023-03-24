import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Constant } from 'src/app/commons/constant.model';
import { SaveSecurityGroupRequest } from 'src/app/models/requests/save-security-group-request.model';
import { SecurityGroupDTO } from 'src/app/models/security-group-dto.model';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-edit-sg',
  templateUrl: './add-edit-sg.component.html',
  styleUrls: ['./add-edit-sg.component.css']
})
export class AddEditSGComponent implements OnInit {

  @Input() sgInfo:SecurityGroupDTO;
  currentSGInfo:SecurityGroupDTO;

  firstLayer:string = Constant.EMPTY_STRING;
  secondLayer:string = Constant.EMPTY_STRING;
  thirdLayer:string = Constant.EMPTY_STRING;
  fourthLayer:string = Constant.EMPTY_STRING;

  constructor(private api:APIService) { }

  ngOnInit(): void {
    this.currentSGInfo = this.sgInfo;
  }

  changeValueLayer(input:any){
    let value = input.value
    switch(input.id){
      case "txtFirstLayer":
        this.firstLayer = value;
        break;
      case "txtSecondLayer":
        this.secondLayer = value;
        break;
      case "txtThirdLayer":
        this.thirdLayer = value;
        break;
      default: /* txtFourthLayer */
        this.fourthLayer = value;
        break;
    }
    this.currentSGInfo.aliasName = this.firstLayer + "-" + this.secondLayer + "-" + this.thirdLayer + "-" + this.fourthLayer;
    this.currentSGInfo.displayName = this.firstLayer + "/" + this.secondLayer + "/" + this.thirdLayer + "/" + this.fourthLayer;
  }

  changeValueType(value:number){
    let isInternal = value == 0;
    let input = document.getElementById("txtFirstLayer") as HTMLInputElement;

    if(input !== null){
      input.value = isInternal ? Constant.EMPTY_STRING : "Partner";
      input.disabled = !isInternal;
      this.changeValueLayer(input);
    }

    this.currentSGInfo.type = value;
  }

  saveSG() {

    let model = new SaveSecurityGroupRequest();
    model.functionID = "01A01";
    model.requestStatus = "A2";
    model.inputSG = this.currentSGInfo;

    //Save security group in database using API
    this.api.saveSG(model).subscribe(
      (res) => {
        //s//wal("Success","Customer saved successfully", "success")
        //.then(() => {
        //  //If success reload page
        //  window.location.reload();
        //})
      },
      (err:HttpErrorResponse) => {
        //If error store the error in errorMessages
        if(err.error?.length !== 0) {
          //this.errorMessages.push(err.error);
          return;
        }
        //this.errorMessages.push(err.error.title);
      }
    );
  }

}
