import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Application } from 'src/app/share/admin/models/application/application.model';
import { ApplicationService } from 'src/app/share/admin/services/application.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApplicationUpdateDto } from 'src/app/share/admin/models/application/application-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { ApplicationType } from 'src/app/share/admin/models/enum/application-type.model';
import { ClientType } from 'src/app/share/admin/models/enum/client-type.model';
import { ConsentType } from 'src/app/share/admin/models/enum/consent-type.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  ApplicationType = ApplicationType;
  ClientType = ClientType;
  ConsentType = ConsentType;

  id!: string;
  isLoading = true;
  isProcessing = false;
  data = {} as Application;
  updateData = {} as ApplicationUpdateDto;
  formGroup!: FormGroup;
  constructor(

    private service: ApplicationService,
    private snb: MatSnackBar,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
    public dialogRef: MatDialogRef<EditComponent>,
    @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
  ) {


    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      this.id = dlgData.id;
    }
  }

  get applicationType() { return this.formGroup.get('applicationType'); }
  get clientId() { return this.formGroup.get('clientId'); }
  get clientSecret() { return this.formGroup.get('clientSecret'); }
  get clientType() { return this.formGroup.get('clientType'); }
  get consentType() { return this.formGroup.get('consentType'); }
  get displayName() { return this.formGroup.get('displayName'); }
  get permissions() { return this.formGroup.get('permissions'); }
  get postLogoutRedirectUris() { return this.formGroup.get('postLogoutRedirectUris'); }
  get properties() { return this.formGroup.get('properties'); }
  get redirectUris() { return this.formGroup.get('redirectUris'); }
  get requirements() { return this.formGroup.get('requirements'); }
  get settings() { return this.formGroup.get('settings'); }
  get authorizationIds() { return this.formGroup.get('authorizationIds'); }
  get tokenIds() { return this.formGroup.get('tokenIds'); }


  ngOnInit(): void {
    this.getDetail();

    // TODO:等待数据加载完成
    // this.isLoading = false;
  }

  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe({
        next: (res) => {
          if (res) {
            this.data = res;
            this.initForm();
            this.isLoading = false;
          } else {
            this.snb.open('');
          }
        },
        error: (error) => {
          this.snb.open(error.detail);
          this.isLoading = false;
        }
      });
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      applicationType: new FormControl(this.data.applicationType, [Validators.maxLength(0)]),
      clientId: new FormControl(this.data.clientId, [Validators.maxLength(100)]),
      clientSecret: new FormControl(this.data.clientSecret, [Validators.maxLength(120)]),
      clientType: new FormControl(this.data.clientType, [Validators.maxLength(0)]),
      consentType: new FormControl(this.data.consentType, [Validators.maxLength(0)]),
      displayName: new FormControl(this.data.displayName, [Validators.maxLength(100)]),
      permissions: new FormControl(this.data.permissions, [Validators.maxLength(0)]),
      postLogoutRedirectUris: new FormControl(this.data.postLogoutRedirectUris, [Validators.maxLength(0)]),
      properties: new FormControl(this.data.properties, [Validators.maxLength(0)]),
      redirectUris: new FormControl(this.data.redirectUris, [Validators.maxLength(0)]),
      requirements: new FormControl(this.data.requirements, [Validators.maxLength(0)]),
      settings: new FormControl(this.data.settings, [Validators.maxLength(0)]),

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
      case 'properties':
        return this.properties?.errors?.['required'] ? 'The properties of application.必填' :
          this.properties?.errors?.['minlength'] ? 'The properties of application.长度最少位' :
            this.properties?.errors?.['maxlength'] ? 'The properties of application.长度最多0位' : '';
      case 'redirectUris':
        return this.redirectUris?.errors?.['required'] ? 'Gets the redirect URIs associated with the application.必填' :
          this.redirectUris?.errors?.['minlength'] ? 'Gets the redirect URIs associated with the application.长度最少位' :
            this.redirectUris?.errors?.['maxlength'] ? 'Gets the redirect URIs associated with the application.长度最多0位' : '';
      case 'requirements':
        return this.requirements?.errors?.['required'] ? 'The requirements of application.必填' :
          this.requirements?.errors?.['minlength'] ? 'The requirements of application.长度最少位' :
            this.requirements?.errors?.['maxlength'] ? 'The requirements of application.长度最多0位' : '';
      case 'settings':
        return this.settings?.errors?.['required'] ? 'The settings of  application.必填' :
          this.settings?.errors?.['minlength'] ? 'The settings of  application.长度最少位' :
            this.settings?.errors?.['maxlength'] ? 'The settings of  application.长度最多0位' : '';
      case 'authorizationIds':
        return this.authorizationIds?.errors?.['required'] ? 'AuthorizationIds必填' :
          this.authorizationIds?.errors?.['minlength'] ? 'AuthorizationIds长度最少位' :
            this.authorizationIds?.errors?.['maxlength'] ? 'AuthorizationIds长度最多0位' : '';
      case 'tokenIds':
        return this.tokenIds?.errors?.['required'] ? 'TokenIds必填' :
          this.tokenIds?.errors?.['minlength'] ? 'TokenIds长度最少位' :
            this.tokenIds?.errors?.['maxlength'] ? 'TokenIds长度最多0位' : '';

      default:
        return '';
    }
  }
  edit(): void {
    if (this.formGroup.valid) {
      this.isProcessing = true;
      this.updateData = this.formGroup.value as ApplicationUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe({
          next: (res) => {
            if (res) {
              this.snb.open('修改成功');
              this.dialogRef.close(res);
              // this.router.navigate(['../../index'], { relativeTo: this.route });
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
