import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/api.service';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SecurityGroupDTO } from 'src/app/models/security-group-dto.model';
import { Constant } from 'src/app/commons/constant.model';

@Component({
  selector: 'app-security-group',
  templateUrl: './security-group.component.html',
  styleUrls: ['./security-group.component.css']
})
export class SecurityGroupComponent implements OnInit {

  modalTitle:string;

  sgList:SecurityGroupDTO[];
  internalID:string;

  constructor(private api:APIService, 
              private modalService: NgbModal,
              config: NgbModalConfig) {
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit(): void {
    this.getSGs();
  }

  getSGs() {
    //Get security groups that is stored in database using API
    this.api.getSGs().subscribe(
      (response:any) => {
        this.sgList = response;
      }
    )
  }

  editSG(content:any, internalID:string){
    this.modalTitle = "Edit Security Group";
		this.modalService.open(content, { size: 'lg' });
    this.internalID = internalID;
  }

  addSG(content:any) {
    this.modalTitle = "Add Security Group";
		this.modalService.open(content, { size: 'lg' });
    this.internalID = Constant.GUID_EMPTY;
  }

  closeModal() {
    this.modalTitle = "";
    this.modalService.dismissAll();
    this.internalID = Constant.GUID_EMPTY;
  }
}
