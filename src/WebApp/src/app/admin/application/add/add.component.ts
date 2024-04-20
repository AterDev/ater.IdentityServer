import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApplicationService } from 'src/app/share/admin/services/application.service';
import { Application } from 'src/app/share/admin/models/application/application.model';
import { ApplicationAddDto } from 'src/app/share/admin/models/application/application-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

import { ApplicationType } from 'src/app/share/admin/models/enum/application-type.model';
import { ClientType } from 'src/app/share/admin/models/enum/client-type.model';
import { ConsentType } from 'src/app/share/admin/models/enum/consent-type.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  ApplicationType = ApplicationType;
  ClientType = ClientType;
  ConsentType = ConsentType;

  formGroup!: FormGroup;
  data = {} as ApplicationAddDto;
  isLoading = true;
  isProcessing = false;
  constructor(
    private service: ApplicationService,
    public snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
  ) {

  }

  get applicationType() { return this.formGroup.get('applicationType'); }
  get clientId() { return this.formGroup.get('clientId'); }
  get clientSecret() { return this.formGroup.get('clientSecret'); }
  get clientType() { return this.formGroup.get('clientType'); }
  get consentType() { return this.formGroup.get('consentType'); }
  get displayName() { return this.formGroup.get('displayName'); }
  get permissions() { return this.formGroup.get('permissions'); }
  get postLogoutRedirectUris() { return this.formGroup.get('postLogoutRedirectUris'); }
  get redirectUris() { return this.formGroup.get('redirectUris'); }


  ngOnInit(): void {
    this.initForm();
    this.isLoading = false;
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      applicationType: new FormControl(ApplicationType.Web, [Validators.maxLength(0)]),
      clientId: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      clientSecret: new FormControl(null, [Validators.maxLength(120), Validators.required]),
      clientType: new FormControl(ClientType.Confidential, [Validators.maxLength(0)]),
      consentType: new FormControl(ConsentType.Explicit, [Validators.maxLength(0)]),
      displayName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      permissions: new FormControl(null, [Validators.maxLength(1000)]),
      postLogoutRedirectUris: new FormControl(null, [Validators.maxLength(1000)]),
      redirectUris: new FormControl(null, [Validators.maxLength(1000)]),
    });
  }

  getValidatorMessage(type: string): string {
    switch (type) {
      case 'applicationType':
        return this.applicationType?.errors?.['required'] ? 'Web/App/Client必填' :
          this.applicationType?.errors?.['minlength'] ? 'Web/App/Client长度最少位' :
            this.applicationType?.errors?.['maxlength'] ? 'Web/App/Client长度最多0位' : '';
      case 'clientId':
        return this.clientId?.errors?.['required'] ? 'ClientId必填' :
          this.clientId?.errors?.['minlength'] ? 'ClientId长度最少位' :
            this.clientId?.errors?.['maxlength'] ? 'ClientId长度最多100位' : '';
      case 'clientSecret':
        return this.clientSecret?.errors?.['required'] ? 'Secret必填' :
          this.clientSecret?.errors?.['minlength'] ? 'Secret长度最少位' :
            this.clientSecret?.errors?.['maxlength'] ? 'Secret长度最多120位' : '';
      case 'clientType':
        return this.clientType?.errors?.['required'] ? 'Confidential as default必填' :
          this.clientType?.errors?.['minlength'] ? 'Confidential as default长度最少位' :
            this.clientType?.errors?.['maxlength'] ? 'Confidential as default长度最多0位' : '';
      case 'consentType':
        return this.consentType?.errors?.['required'] ? '同意书类型必填' :
          this.consentType?.errors?.['minlength'] ? '同意书类型长度最少位' :
            this.consentType?.errors?.['maxlength'] ? '同意书类型长度最多0位' : '';
      case 'displayName':
        return this.displayName?.errors?.['required'] ? '名称必填' :
          this.displayName?.errors?.['minlength'] ? '名称长度最少位' :
            this.displayName?.errors?.['maxlength'] ? '名称长度最多100位' : '';
      case 'permissions':
        return this.permissions?.errors?.['required'] ? 'The permissions of application.必填' :
          this.permissions?.errors?.['minlength'] ? 'The permissions of application.长度最少位' :
            this.permissions?.errors?.['maxlength'] ? 'The permissions of application.长度最多0位' : '';
      case 'postLogoutRedirectUris':
        return this.postLogoutRedirectUris?.errors?.['required'] ? 'The post-logout redirect URIs of  application.必填' :
          this.postLogoutRedirectUris?.errors?.['minlength'] ? 'The post-logout redirect URIs of  application.长度最少位' :
            this.postLogoutRedirectUris?.errors?.['maxlength'] ? 'The post-logout redirect URIs of  application.长度最多0位' : '';
      case 'redirectUris':
        return this.redirectUris?.errors?.['required'] ? 'Gets the redirect URIs associated with the application.必填' :
          this.redirectUris?.errors?.['minlength'] ? 'Gets the redirect URIs associated with the application.长度最少位' :
            this.redirectUris?.errors?.['maxlength'] ? 'Gets the redirect URIs associated with the application.长度最多0位' : '';

      default:
        return '';
    }
  }

  add(): void {
    if (this.formGroup.valid) {
      this.isProcessing = true;
      let data = this.formGroup.value as ApplicationAddDto;
      data.postLogoutRedirectUris = this.postLogoutRedirectUris?.value.split(',');
      data.redirectUris = this.redirectUris?.value.split(',');

      this.service.add(data)
        .subscribe({
          next: (res) => {
            if (res) {
              this.snb.open('添加成功');
              this.router.navigate(['../index'], { relativeTo: this.route });
            }
          },
          error: (error) => {
            this.snb.open(error.detail);
            this.isProcessing = false;
          },
          complete: () => {
            this.isProcessing = false;
          }
        });
    } else {
      this.snb.open('表单验证不通过，请检查填写的内容!');
    }
  }

  back(): void {
    this.location.back();
  }
}
