import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SecurityGroupComponent } from './security-group/security-group.component';
import { AddEditSGComponent } from './security-group/add-edit-sg/add-edit-sg.component';
import { ShowSGListComponent } from './security-group/show-sg-list/show-sg-list.component';

@NgModule({
  declarations: [
    AppComponent,
    SecurityGroupComponent,
    AddEditSGComponent,
    ShowSGListComponent
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
