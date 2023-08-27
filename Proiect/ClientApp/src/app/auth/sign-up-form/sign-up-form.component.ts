
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { UserService } from '../../user.service';
import { UserAuthRequestDto } from '../../UserAuthRequestDto.model';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.css']
})
export class  SignUpFormComponent {
    signUpForm: FormGroup;

  constructor(private fb: FormBuilder, private userService: UserService) {
    this.signUpForm = this.fb.group({
      name: [''],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
      validator: this.MustMatch('password', 'confirmPassword')
    });
  }

  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        // return if another validator has already found an error on the matchingControl
        return;
      }

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }


  onSubmit() {
    console.log("aici");
    if (this.signUpForm.valid) {

      const email = this.signUpForm.value.email;
      const password = this.signUpForm.value.password;
      const name = this.signUpForm.value.name;

      this.userService.getAll().subscribe(users => {
        console.log("aici");
        const user = users.find(u => u.email === email);
        if (user) {
          // user already exists, authenticate
          this.userService.authenticate(email, password)
            .subscribe(
              response => {
                // handle successful authentication here
                localStorage.setItem('jwtToken', response.jwtToken);
                localStorage.setItem('userId', response.id);
              },
              error => {
                // handle authentication error here
              }
            );
        } else {
          // user doesn't exist, create new user
          const userDto: UserAuthRequestDto = { email: email, password: password, name: name };
          this.userService.create(userDto)
            .subscribe(
              newUser => {
                console.log("bravo");
                this.userService.authenticate(email, password)
                  .subscribe(
                    response => {
                      // handle successful authentication here
                      localStorage.setItem('jwtToken', response.jwtToken);
                      localStorage.setItem('userId', response.id);
                    },
                    error => {
                      // handle authentication error here
                    }
                  );
              },
              error => {
                // handle user creation error here
              }
            );
        }
      });
    }

  }
}
