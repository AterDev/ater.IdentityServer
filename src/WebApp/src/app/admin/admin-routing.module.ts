import { NgModule } from '@angular/core';
import { RouteReuseStrategy, RouterModule, Routes } from '@angular/router';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { CustomRouteReuseStrategy } from '../custom-route-strategy';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: 'application', redirectTo: 'application/index', pathMatch: 'full' },
    ]
  },
  { path: '', redirectTo: 'application', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [{
    provide: RouteReuseStrategy,
    useClass: CustomRouteReuseStrategy
  }]

})
export class AdminRoutingModule { }
