import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-edit-sg',
  templateUrl: './add-edit-sg.component.html',
  styleUrls: ['./add-edit-sg.component.css']
})
export class AddEditSGComponent implements OnInit {

  constructor(private api:APIService) { }

  ngOnInit(): void {
  }

}
