import { Routes } from '@angular/router';
import { NotfoundComponent } from './public/notfound/notfound.component';
import { AuthGuard } from './share/auth.guard';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { AuthorizeComponent } from './public/authorize/authorize.component';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'connect/authorize', component: AuthorizeComponent },
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      { path: '', redirectTo: 'application', pathMatch: 'full' },
      {
        path: '',
        children: [
          { path: 'application', redirectTo: 'application/index', pathMatch: 'full' },
        ]
      },
      {
        path: 'application',
        children: [
          { path: '', pathMatch: 'full', redirectTo: 'index' },
          {
            path: 'index', loadComponent: () => import('./admin/application/index/index.component')
              .then(m => m.IndexComponent)
          },
          { path: 'add', loadComponent: () => import('./admin/application/add/add.component').then(m => m.AddComponent) },
          { path: 'detail/:id', loadComponent: () => import('./admin/application/detail/detail.component').then(m => m.DetailComponent) },
          { path: 'edit/:id', loadComponent: () => import('./admin/application/edit/edit.component').then(m => m.EditComponent) },
        ]
      },
      {
        path: 'config',
        canActivateChild: [AuthGuard],
        children: [
          { path: '', pathMatch: 'full', redirectTo: 'index' },
          { path: 'index', loadComponent: () => import('./admin/config/index/index.component').then(m => m.IndexComponent) },
        ]
      },
      {
        path: 'scope',
        canActivateChild: [AuthGuard],
        children: [
          { path: '', pathMatch: 'full', redirectTo: 'index' },
          { path: 'index', loadComponent: () => import('./admin/scope/index/index.component').then(m => m.IndexComponent) },
          { path: 'add', loadComponent: () => import('./admin/scope/add/add.component').then(m => m.AddComponent) },
          { path: 'detail/:id', loadComponent: () => import('./admin/scope/detail/detail.component').then(m => m.DetailComponent) },
          { path: 'edit/:id', loadComponent: () => import('./admin/scope/edit/edit.component').then(m => m.EditComponent) },
        ]
      }
    ]
  },
  { path: '**', component: NotfoundComponent },
];
