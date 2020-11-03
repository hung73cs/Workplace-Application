import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { NgxAuthRoutingModule } from './auth-routing.module';
import { NbAuthModule } from '@nebular/auth';
import { 
  NbAlertModule,
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbDatepicker,
  NbDatepickerModule,
  NbInputModule
} from '@nebular/theme';
import { NgxLoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ChangepasswordComponent } from './auth/changepassword/changepassword.component';
import { GetuserComponent } from './user/getuser/getuser.component';
import { UpdateuserComponent } from './user/updateuser/updateuser.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import {NbMomentDateModule } from '@nebular/moment';

//import { RegisterComponent } from './components/register/register.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    NbAlertModule,
    NbInputModule,
    NbButtonModule,
    NbDatepickerModule,
    NbCheckboxModule,
    NgxAuthRoutingModule,
    NbAuthModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbMomentDateModule
  ],
  declarations: [
    // ... here goes our new components
  NgxLoginComponent,
    RegisterComponent,
    ChangepasswordComponent,
    GetuserComponent,
    UpdateuserComponent
],
})
export class NgxAuthModule {
}