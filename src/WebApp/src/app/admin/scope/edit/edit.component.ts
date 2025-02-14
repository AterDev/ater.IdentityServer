import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { Location, NgIf } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatToolbar } from '@angular/material/toolbar';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { ScopeUpdateDto } from 'src/app/services/admin/scope/models/scope-update-dto.model';
import { Scope } from 'src/app/services/admin/scope/models/scope.model';
import { ScopeService } from 'src/app/services/admin/scope/scope.service';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  imports: [MatToolbar, NgIf, ReactiveFormsModule, MatFormField, MatLabel, MatInput, MatError, MatButton]
})
export class EditComponent implements OnInit {

  id!: string;
  isLoading = true;
  isProcessing = false;
  data = {} as Scope;
  updateData = {} as ScopeUpdateDto;
  formGroup!: FormGroup;
  constructor(

    private service: ScopeService,
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

  get description() { return this.formGroup.get('description'); }
  get displayName() { return this.formGroup.get('displayName'); }
  get name() { return this.formGroup.get('name'); }
  get properties() { return this.formGroup.get('properties'); }


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
      description: new FormControl(this.data.description, [Validators.maxLength(500)]),
      displayName: new FormControl(this.data.displayName, [Validators.maxLength(100)]),
      name: new FormControl(this.data.name, [Validators.maxLength(100)]),
      properties: new FormControl(this.data.properties, [Validators.maxLength(0)]),

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
  edit(): void {
    if (this.formGroup.valid) {
      this.isProcessing = true;
      this.updateData = this.formGroup.value as ScopeUpdateDto;
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
