import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ShareModule } from '../share/share.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ShareModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
