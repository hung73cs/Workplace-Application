import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NbAuthComponent, NbLoginComponent } from '@nebular/auth';
import { ChangepasswordComponent } from './auth/changepassword/changepassword.component';
import { NgxLoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { GetuserComponent } from './user/getuser/getuser.component';

export const routes: Routes = [
  // .. here goes our components routes
  {
    path: '',
    component: NbLoginComponent, 
    children: [
      {
        path: 'login',
        component: NgxLoginComponent, // <---
      },
      {
        path: 'register',
        component: RegisterComponent, // <---
      },
      {
        path: 'changepassword',
        component: ChangepasswordComponent, // <---
      },
      {
        path: 'getall',
        component: GetuserComponent, // <---
      }   
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NgxAuthRoutingModule {
}