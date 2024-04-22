import { NgModule } from '@angular/core';
import { RouteReuseStrategy, RouterModule, Routes } from '@angular/router';
import { CustomRouteReuseStrategy } from '../custom-route-strategy';

const routes: Routes = [
  { path: '', redirectTo: 'application', pathMatch: 'full' },
  {
    path: '',
    children: [
      { path: 'application', redirectTo: 'application/index', pathMatch: 'full' },
    ]
  }
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
