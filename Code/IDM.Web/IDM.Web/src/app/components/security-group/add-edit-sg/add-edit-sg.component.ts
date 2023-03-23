import { Component, Input, OnInit } from '@angular/core';
import { Constant } from 'src/app/commons/constant.model';
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
    
  }

}
