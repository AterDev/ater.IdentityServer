import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Location, NgIf } from '@angular/common';
import { MatToolbar } from '@angular/material/toolbar';
import { MatIconButton } from '@angular/material/button';
import { MatTooltip } from '@angular/material/tooltip';
import { MatIcon } from '@angular/material/icon';
import { MatCard, MatCardContent, MatCardActions } from '@angular/material/card';
import { Application } from 'src/app/services/admin/application/models/application.model';
import { ApplicationService } from 'src/app/services/admin/application/application.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css'],
  imports: [MatToolbar, MatIconButton, MatTooltip, MatIcon, NgIf, MatCard, MatCardContent, MatCardActions]
})
export class DetailComponent implements OnInit {
  id!: string;
  isLoading = true;
  data = {} as Application;
  constructor(
    private service: ApplicationService,
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
          if (res) {
            this.data = res;
            this.isLoading = false;
          }
        },
        error: (error) => {
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
