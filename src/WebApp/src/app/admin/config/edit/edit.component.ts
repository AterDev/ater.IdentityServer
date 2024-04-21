import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Config } from 'src/app/share/admin/models/config/config.model';
import { ConfigService } from 'src/app/share/admin/services/config.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfigUpdateDto } from 'src/app/share/admin/models/config/config-update-dto.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { ConfigValueType } from 'src/app/share/admin/models/enum/config-value-type.model';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
    ConfigValueType = ConfigValueType;

  id!: string;
  isLoading = true;
  isProcessing = false;
  data = {} as Config;
  updateData = {} as ConfigUpdateDto;
  formGroup!: FormGroup;
    constructor(
    
    private service: ConfigService,
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

    get group() { return this.formGroup.get('group'); }
    get key() { return this.formGroup.get('key'); }
    get value() { return this.formGroup.get('value'); }
    get valueType() { return this.formGroup.get('valueType'); }


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
      group: new FormControl(this.data.group, [Validators.maxLength(100)]),
      key: new FormControl(this.data.key, [Validators.maxLength(100)]),
      value: new FormControl(this.data.value, [Validators.maxLength(0)]),
      valueType: new FormControl(this.data.valueType, [Validators.maxLength(0)]),

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
  edit(): void {
    if(this.formGroup.valid) {
      this.isProcessing = true;
      this.updateData = this.formGroup.value as ConfigUpdateDto;
      this.service.update(this.id, this.updateData)
        .subscribe({
          next: (res) => {
            if(res){
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
