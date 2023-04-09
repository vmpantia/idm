import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Constant } from 'src/app/commons/constant.model';
import { SaveSecurityGroupRequest } from 'src/app/models/requests/save-security-group-request.model';
import { SecurityGroupDTO } from 'src/app/models/security-group-dto.model';
import { APIService } from 'src/app/services/api.service';
import { UtilityService } from 'src/app/services/utility.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edit-sg',
  templateUrl: './edit-sg.component.html',
  styleUrls: ['./edit-sg.component.css']
})
export class EditSGComponent implements OnInit {

  internalID:string;

  constructor(private route: ActivatedRoute,) {}

  ngOnInit(): void {
    this.internalID = this.route.snapshot.paramMap.get('internalID') as string;
  }
}