import { NgModule } from '@angular/core';
import { ApplicationRoutingModule } from './application-routing.module';
import { ShareModule } from 'src/app/share/share.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';
import { EnumTextPipe } from 'src/app/share/admin/pipe/enum-text.pipe';

@NgModule({
  declarations: [IndexComponent, DetailComponent, AddComponent, EditComponent, EnumTextPipe],
  imports: [
    ComponentsModule,
    ShareModule,
    ApplicationRoutingModule
  ]
})
export class ApplicationModule { }