import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/api.service';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-security-group',
  templateUrl: './security-group.component.html',
  styleUrls: ['./security-group.component.css']
})
export class SecurityGroupComponent implements OnInit {

  modalTitle:string;
	closeResult = '';

  sgList:any[];
  sgInfo:any;

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
      (res:any[]) => {
        this.sgList = res;
      }
    )
  }

  editSG(content:any, internalID:any){
    this.modalTitle = "Edit Security Group";
		this.modalService.open(content);

  }

  addSG(content:any) {
    this.modalTitle = "Add Security Group";
		this.modalService.open(content);
  }

  closeModal() {
    this.modalTitle = "";
    this.modalService.dismissAll();
    this.getSGs();
  }
}
