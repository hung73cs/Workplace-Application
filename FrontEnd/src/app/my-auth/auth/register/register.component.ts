import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth.service';
import { RegisterModel } from '../_models/register.model';
import { ChangeDetectorRef, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { NbAuthService, NbRegisterComponent, NB_AUTH_OPTIONS } from '@nebular/auth';

@Component({
  selector: 'ngx-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent extends NbRegisterComponent {

  userInfo: RegisterModel = new RegisterModel();
  confirmPassword: string;
  match: boolean = false;

  constructor(protected service: NbAuthService,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    protected cd: ChangeDetectorRef,
    protected router: Router, private authService: AuthService) {
    super(service, options, cd, router);
  }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.userInfo).toPromise()
      .then(result => {
        if (result.status == true) {
          console.log(this.userInfo);
          this.router.navigateByUrl('pages');
        }
        else {
          alert(result.value);
        }
      }
      )
  }

  comparePassword(){
    if(!(this.confirmPassword==this.userInfo.passWord))
    {
      return true;
    }
    else return false;
  }
}