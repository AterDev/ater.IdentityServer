import { NgModule } from '@angular/core';
import { ConfigRoutingModule } from './config-routing.module';
import { EnumPipeModule, ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';

@NgModule({
  declarations: [IndexComponent],
  imports: [
    ComponentsModule,
    ShareModule,
    EnumPipeModule,
    ConfigRoutingModule
  ]
})
export class ConfigModule { }
