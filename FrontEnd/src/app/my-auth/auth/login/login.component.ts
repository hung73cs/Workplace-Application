import { ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbAuthService, NbLoginComponent, NB_AUTH_OPTIONS } from '@nebular/auth';
import { LoginModel } from '../_models/login.model';
import { AuthService } from '../../auth.service';


@Component({
  selector: 'ngx-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class NgxLoginComponent extends NbLoginComponent {

  userInfo: LoginModel = new LoginModel();

  constructor(protected service: NbAuthService,
    @Inject(NB_AUTH_OPTIONS) protected options = {},
    protected cd: ChangeDetectorRef,
    protected router: Router, private authService: AuthService) {
        super(service, options, cd, router);
    } 

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.userInfo).toPromise()
    .then(result => {
      if (result.status == true) {
        localStorage.setItem('token', JSON.stringify(result.value));
        this.router.navigateByUrl('pages');
      }
      else {
        alert(result.value);
      }
    })
  }
}
