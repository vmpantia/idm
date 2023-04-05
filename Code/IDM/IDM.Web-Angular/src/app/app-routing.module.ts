import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SecurityGroupComponent } from './components/security-group/security-group.component';
import { AddSGComponent } from './components/security-group/add-sg/add-sg.component';
import { EditSGComponent } from './components/security-group/edit-sg/edit-sg.component';

const routes: Routes = [
  {path: 'securitygroup', component:SecurityGroupComponent},
  {path: 'securitygroup/add', component:AddSGComponent },
  {path: 'securitygroup/edit/:internalID', component:EditSGComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
