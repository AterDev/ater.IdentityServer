import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './share/auth.guard';
import { AuthorizeComponent } from './public/authorize/authorize.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';

const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    { path: 'connect/authorize', component: AuthorizeComponent },

    // admin module
    {
        path: 'admin',
        component: AdminLayoutComponent,
        loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
        canActivate: [AuthGuard],
        canActivateChild: [AuthGuard],
    },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }