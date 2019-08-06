import { Component, OnInit } from '@angular/core';
import { MessageService } from "primeng/components/common/messageservice";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [MessageService]
})
export class LoginComponent implements OnInit {

  user: any = { name: '', password: '' };
  isPassword: boolean = true;
  constructor(private messageService: MessageService, private router: Router) { }

  ngOnInit() {
  }

  showError(msg) {
    this.messageService.clear();
    this.messageService.add({
      severity: 'error',
      summary: 'Error Message',
      detail: msg,
      life: 4000
    });
  }

  showPassword(event) {
    //Show password to client
    if (this.isPassword) {
      this.isPassword = false;
      event.currentTarget.className = "fa fa-fw fa-eye field-icon";
    }
    else {
      this.isPassword = true;
      event.currentTarget.className = "fa fa-fw fa-eye-slash field-icon";
    }

  }

  onLogin() {
 
    if (!this.user.name || !this.user.password)
      this.showError('You must insert user name and password');

    if (this.user.name && this.user.password) {

      if (this.user.password == '123456')
        this.router.navigate(['../search'], { queryParams: { userName: this.user.name }, skipLocationChange: true });
      else
        this.showError('Incorrect  password');
    }
  }
}
