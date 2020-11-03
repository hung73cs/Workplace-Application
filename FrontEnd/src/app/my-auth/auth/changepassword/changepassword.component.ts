import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbAuthService, NbResetPasswordComponent, NB_AUTH_OPTIONS } from '@nebular/auth';
import { AuthService } from '../../auth.service';
import { ChangePasswordModel } from '../_models/change-password.model';

@Component({
  selector: 'ngx-changepassword',
  templateUrl: './changepassword.component.html',
  styleUrls: ['./changepassword.component.scss']
})
export class ChangepasswordComponent extends NbResetPasswordComponent {
  
  changePass: ChangePasswordModel = new ChangePasswordModel();
  confirmPassword: string;
  
  constructor(protected service: NbAuthService,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    protected cd: ChangeDetectorRef,
    protected router: Router, private authService: AuthService) {
    super(service, options, cd, router);
    this.changePass.UserName="";
  }

  ngOnInit(): void {
  }

  changePassword() {
    this.authService.changePassword(this.changePass).toPromise()
      .then(result => {
        if (result.status == true) {
          console.log(this.changePass);
          this.router.navigateByUrl('pages');
        }
        else {
          alert(result.value);
        }
      }
      )
  }

  comparePassword(){
    if(!(this.confirmPassword==this.changePass.NewPassword))
    {
      return true;
    }
    else return false;
  }
}
