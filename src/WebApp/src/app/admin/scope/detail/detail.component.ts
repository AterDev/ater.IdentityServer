import { Component, OnInit } from '@angular/core';
import { ScopeService } from 'src/app/share/admin/services/scope.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Scope } from 'src/app/share/admin/models/scope/scope.model';
import { Location } from '@angular/common';

@Component({
    selector: 'app-detail',
    templateUrl: './detail.component.html',
    styleUrls: ['./detail.component.css'],
    standalone: false
})
export class DetailComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as Scope;
  constructor(
    private service: ScopeService,
    private snb: MatSnackBar,
    private route: ActivatedRoute,
    public location: Location,
    private router: Router,
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.id = id;
    } else {
      // TODO: id为空

    }
  }
  ngOnInit(): void {
    this.getDetail();
  }
  getDetail(): void {
    this.service.getDetail(this.id)
      .subscribe({
        next: (res) => {
          if(res) {
            this.data = res;
              this.isLoading = false;
            }
        },
        error:(error) => {
          this.snb.open(error);
        }
      })
  }
  back(): void {
    this.location.back();
  }

  edit(): void {
    this.router.navigate(['../../edit/' + this.id], { relativeTo: this.route });

  }
}
