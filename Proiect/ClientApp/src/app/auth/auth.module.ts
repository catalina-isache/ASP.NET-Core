import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


// Components
import { LoginFormComponent } from "./login-form/login-form.component";
import { SignUpFormComponent } from "./sign-up-form/sign-up-form.component";

// Modules
import { AuthRoutingModule } from './auth-routing.module';
//import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//import { MatButtonModule, MatCardModule, MatFormFieldModule, MatIconModule } from '@angular/material';
//import { MatListModule } from '@angular/material/list';
//import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [LoginFormComponent, SignUpFormComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    CommonModule,
   // MatListModule,
    ReactiveFormsModule,
    //   MatCardModule,
    //   MatFormFieldModule,
    //  MatIconModule,
    //   MatButtonModule,
    FormsModule,
    //   MatInputModule
  ]
})
export class AuthModule { }
