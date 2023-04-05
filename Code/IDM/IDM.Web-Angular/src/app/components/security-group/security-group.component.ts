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

  constructor(private api:APIService) {  }

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
}
