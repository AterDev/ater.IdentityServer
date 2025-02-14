import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { Observable, forkJoin } from 'rxjs';
import { MatToolbar, MatToolbarRow } from '@angular/material/toolbar';
import { NgIf } from '@angular/common';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { MatCheckbox } from '@angular/material/checkbox';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ConfigService } from 'src/app/services/admin/config/config.service';
import { ConfigFilterDto } from 'src/app/services/admin/config/models/config-filter-dto.model';
import { ConfigItemDtoPageList } from 'src/app/services/admin/config/models/config-item-dto-page-list.model';
import { ConfigItemDto } from 'src/app/services/admin/config/models/config-item-dto.model';
import { EnumDictionary } from 'src/app/services/admin/config/models/enum-dictionary.model';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css'],
  imports: [MatToolbar, MatToolbarRow, NgIf, MatProgressSpinner, MatCheckbox, ReactiveFormsModule, FormsModule]
})
export class IndexComponent implements OnInit {
  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
  isLoading = true;
  isProcessing = false;
  total = 0;
  data: ConfigItemDto[] = [];

  // 终结点选项
  endpointValue: number = 0;
  grantTypeValue: number = 0;

  endpointOptions: EnumDictionary[] = [];
  grantTypeOptions: EnumDictionary[] = [];

  filter: ConfigFilterDto;
  constructor(
    private service: ConfigService,
    private snb: MatSnackBar,
    private dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
  ) {

    this.filter = {
      pageIndex: 1,
      pageSize: 12,
      group: 'Default'
    };
  }

  ngOnInit(): void {
    forkJoin([this.getEnums(), this.getList()])
      .subscribe({
        next: ([enums, res]) => {
          // 获取枚举选项
          if (enums) {
            let map = new Map<string, []>(Object.entries(enums));
            this.endpointOptions = map.get('Endpoint') ?? [];
            this.grantTypeOptions = map.get('GrantType') ?? [];
          }
          if (res) {
            if (res.data) {
              this.data = res.data;
              this.total = res.count;
            }
          } else {
            this.snb.open('');
          }
        },
        error: (error) => {
          this.snb.open(error.detail);
          this.isLoading = false;
        },
        complete: () => {
          this.isLoading = false;
        }
      });
  }


  getEnums(): Observable<Map<string, EnumDictionary[]>> {
    return this.service.getEnums();
  }

  getList(): Observable<ConfigItemDtoPageList> {
    return this.service.filter(this.filter);

  }

  jumpTo(pageNumber: string): void {
    const number = parseInt(pageNumber);
    if (number > 0 && number < this.paginator.getNumberOfPages()) {
      this.filter.pageIndex = number;
      this.getList();
    }
  }

  /**
   * 编辑
   */
  edit(id: string): void {
    this.router.navigate(['../edit/' + id], { relativeTo: this.route });
  }
}
