import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { FormControl } from '@angular/forms';
import { UserService } from '../../user.service';
@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private fb: FormBuilder, private userService: UserService) {

  }


  onSubmit() {
    if (this.loginForm.valid) {
      const email = this.loginForm.value.email;
      const password = this.loginForm.value.password;
      this.userService.authenticate(email, password)
        .subscribe(
            (  response: { jwtToken: string; id: string; }) => {
            console.log(response);
            // handle successful authentication here
            localStorage.setItem('jwtToken', response.jwtToken);
            localStorage.setItem('userId', response.id);
          },
            (          error: any) => {
            // handle authentication error here
          }
        );
    }
  }
}
