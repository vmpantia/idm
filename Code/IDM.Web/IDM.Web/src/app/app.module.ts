import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SecurityGroupComponent } from './components/security-group/security-group.component';
import { AddEditSGComponent } from './components/security-group/add-edit-sg/add-edit-sg.component';
import { ShowSGListComponent } from './components/security-group/show-sg-list/show-sg-list.component';
import { ComputerComponent } from './components/computer/computer.component';

@NgModule({
  declarations: [
    AppComponent,
    SecurityGroupComponent,
    AddEditSGComponent,
    ShowSGListComponent,
    ComputerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
