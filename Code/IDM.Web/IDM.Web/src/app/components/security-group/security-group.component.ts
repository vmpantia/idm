import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-security-group',
  templateUrl: './security-group.component.html',
  styleUrls: ['./security-group.component.css']
})
export class SecurityGroupComponent implements OnInit {

  constructor(private api:APIService) { }

  sgList:any[];
  sgInfo:any;

  ngOnInit(): void {
    this.getSGs();
  }
  
  getSGs() {
    //Get security groups that is stored in database using API
    this.api.getSGs().subscribe(
      (res) => {
        this.sgList = res;
      }
    )
  }
}
