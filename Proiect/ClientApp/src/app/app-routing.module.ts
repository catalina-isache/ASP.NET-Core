import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';

const routes: Routes = [{
  path: 'home',
  component: HomeComponent
},
//{
//path: "admin",
// canActivate: [AuthGuard],
//loadChildren: () => import('./pages/admin/admin.module').then(m => m.AdminModule)
//},
{
  path: "auth",
  loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
