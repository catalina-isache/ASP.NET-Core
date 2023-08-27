import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

// components
import { LoginFormComponent } from "./login-form/login-form.component";
import { SignUpFormComponent } from "./sign-up-form/sign-up-form.component";
const routes: Routes = [
  {
    path: "signup",
    component: SignUpFormComponent
  },
  {
    path: "login",
    component: LoginFormComponent
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
