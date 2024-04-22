import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ShareModule } from '../share/share.module';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { ApplicationModule } from './application/application.module';
import { ScopeModule } from './scope/scope.module';
import { ConfigModule } from './config/config.module';
import { EnumTextPipe } from '../share/admin/pipe/enum-text.pipe';


@NgModule({
  declarations: [AdminLayoutComponent, EnumTextPipe],
  imports: [
    CommonModule,
    ShareModule,
    AdminRoutingModule,
    ApplicationModule,
    ScopeModule,
    ConfigModule
  ]
})
export class AdminModule { }