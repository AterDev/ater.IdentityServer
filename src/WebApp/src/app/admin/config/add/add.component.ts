import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ConfigService } from 'src/app/share/admin/services/config.service';
import { Config } from 'src/app/share/admin/models/config/config.model';
import { ConfigAddDto } from 'src/app/share/admin/models/config/config-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';

import { ConfigValueType } from 'src/app/share/admin/models/enum/config-value-type.model';

@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
      ConfigValueType = ConfigValueType;

    formGroup!: FormGroup;
    data = {} as ConfigAddDto;
    isLoading = true;
    isProcessing = false;
    constructor(
        
        private service: ConfigService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location,
         public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get group() { return this.formGroup.get('group'); }
    get key() { return this.formGroup.get('key'); }
    get value() { return this.formGroup.get('value'); }
    get valueType() { return this.formGroup.get('valueType'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      group: new FormControl(null, [Validators.maxLength(100)]),
      key: new FormControl(null, [Validators.required,Validators.maxLength(100)]),
      value: new FormControl(null, [Validators.required,Validators.maxLength(0)]),
      valueType: new FormControl(null, [Validators.maxLength(0)]),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'group':
        return this.group?.errors?.['required'] ? 'Group必填' :
          this.group?.errors?.['minlength'] ? 'Group长度最少位' :
          this.group?.errors?.['maxlength'] ? 'Group长度最多100位' : '';
      case 'key':
        return this.key?.errors?.['required'] ? 'Key必填' :
          this.key?.errors?.['minlength'] ? 'Key长度最少位' :
          this.key?.errors?.['maxlength'] ? 'Key长度最多100位' : '';
      case 'value':
        return this.value?.errors?.['required'] ? 'Value必填' :
          this.value?.errors?.['minlength'] ? 'Value长度最少位' :
          this.value?.errors?.['maxlength'] ? 'Value长度最多0位' : '';
      case 'valueType':
        return this.valueType?.errors?.['required'] ? 'ValueType必填' :
          this.valueType?.errors?.['minlength'] ? 'ValueType长度最少位' :
          this.valueType?.errors?.['maxlength'] ? 'ValueType长度最多0位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    this.isProcessing = true;
    const data = this.formGroup.value as ConfigAddDto;
    this.service.add(data)
      .subscribe({
        next: (res) => {
          if (res) {
            this.snb.open('添加成功');
             this.dialogRef.close(res);
            //this.router.navigate(['../index'], { relativeTo: this.route });
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
