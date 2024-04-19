import { Component, OnInit } from '@angular/core';
// import { OAuthService, OAuthErrorEvent, UserInfo } from 'angular-oauth2-oidc';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../../auth/login.service';
import { SystemUserService } from 'src/app/share/admin/services/system-user.service';
import { MatCardModule } from '@angular/material/card';
import { FormModule } from 'src/app/share/share.module';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  standalone: true,
  imports: [FormModule, MatCardModule],
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;
  constructor(
    private loginService: LoginService,
    private service: SystemUserService,
    private router: Router

  ) {
  }
  get username() { return this.loginForm.get('username'); }
  get password() { return this.loginForm.get('password'); }
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.required, Validators.minLength(3)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(50)])
    });
  }

  /**
   * 错误信息
   * @param type 字段名称
   */
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'username':
        return this.username?.errors?.['required'] ? '用户名必填' :
          this.username?.errors?.['minlength']
            || this.username?.errors?.['maxlength'] ? '用户名长度3-20位' : '';
      case 'password':
        return this.password?.errors?.['required'] ? '密码必填' :
          this.password?.errors?.['minlength'] ? '密码长度不可低于6位' :
            this.password?.errors?.['maxlength'] ? '密码长度不可超过50' : '';
      default:
        break;
    }
    return '';
  }
  doLogin(): void {

    const data = this.loginForm.value;
    // 登录接口
    this.service.login(data)
      .subscribe(res => {
        this.loginService.saveLoginState(res);
        this.router.navigate(['/admin']);
      });
  }


  logout(): void {
    this.loginService.logout();
  }
}
