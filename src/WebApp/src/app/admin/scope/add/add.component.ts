import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ScopeService } from 'src/app/share/admin/services/scope.service';
import { Scope } from 'src/app/share/admin/models/scope/scope.model';
import { ScopeAddDto } from 'src/app/share/admin/models/scope/scope-add-dto.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatDialogRef } from '@angular/material/dialog';


@Component({
    selector: 'app-add',
    templateUrl: './add.component.html',
    styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
    
    formGroup!: FormGroup;
    data = {} as ScopeAddDto;
    isLoading = true;
    isProcessing = false;
    constructor(
        
        private service: ScopeService,
        public snb: MatSnackBar,
        private router: Router,
        private route: ActivatedRoute,
        private location: Location,
         public dialogRef: MatDialogRef<AddComponent>,
        // @Inject(MAT_DIALOG_DATA) public dlgData: { id: '' }
    ) {

    }

    get description() { return this.formGroup.get('description'); }
    get displayName() { return this.formGroup.get('displayName'); }
    get name() { return this.formGroup.get('name'); }
    get properties() { return this.formGroup.get('properties'); }


  ngOnInit(): void {
    this.initForm();
    
    // TODO:获取其他相关数据后设置加载状态
    this.isLoading = false;
  }
  
  initForm(): void {
    this.formGroup = new FormGroup({
      description: new FormControl(null, [Validators.maxLength(500)]),
      displayName: new FormControl(null, [Validators.maxLength(100)]),
      name: new FormControl(null, [Validators.maxLength(100)]),
      properties: new FormControl(null, [Validators.maxLength(0)]),

    });
  }
  getValidatorMessage(type: string): string {
    switch (type) {
      case 'description':
        return this.description?.errors?.['required'] ? 'Description必填' :
          this.description?.errors?.['minlength'] ? 'Description长度最少位' :
          this.description?.errors?.['maxlength'] ? 'Description长度最多500位' : '';
      case 'displayName':
        return this.displayName?.errors?.['required'] ? 'DisplayName必填' :
          this.displayName?.errors?.['minlength'] ? 'DisplayName长度最少位' :
          this.displayName?.errors?.['maxlength'] ? 'DisplayName长度最多100位' : '';
      case 'name':
        return this.name?.errors?.['required'] ? 'Name必填' :
          this.name?.errors?.['minlength'] ? 'Name长度最少位' :
          this.name?.errors?.['maxlength'] ? 'Name长度最多100位' : '';
      case 'properties':
        return this.properties?.errors?.['required'] ? 'Properties必填' :
          this.properties?.errors?.['minlength'] ? 'Properties长度最少位' :
          this.properties?.errors?.['maxlength'] ? 'Properties长度最多0位' : '';

      default:
    return '';
    }
  }

  add(): void {
    if(this.formGroup.valid) {
    this.isProcessing = true;
    const data = this.formGroup.value as ScopeAddDto;
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
