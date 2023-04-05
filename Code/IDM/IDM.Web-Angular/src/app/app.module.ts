import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

/* BOOTSTRAP */
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

/* COMPONENTS */
import { SecurityGroupComponent } from './components/security-group/security-group.component';
import { AddSGComponent } from './components/security-group/add-sg/add-sg.component';
import { EditSGComponent } from './components/security-group/edit-sg/edit-sg.component';
import { AddEditSGComponent } from './components/security-group/add-edit-sg/add-edit-sg.component';
import { ComputerComponent } from './components/computer/computer.component';

/* SERVICES */
import { APIService } from './services/api.service';

@NgModule({
  declarations: [
    AppComponent,
    SecurityGroupComponent,
    AddEditSGComponent,
    ComputerComponent,
    AddSGComponent,
    EditSGComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [APIService],
  bootstrap: [AppComponent]
})
export class AppModule { }
