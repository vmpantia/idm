import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SecurityGroupComponent } from './components/security-group/security-group.component';

const routes: Routes = [
  {path: 'securitygroup', component:SecurityGroupComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
