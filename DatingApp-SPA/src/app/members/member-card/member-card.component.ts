import { Component, OnInit, Input } from '@angular/core';
import { User } from 'src/app/_models/User';
import { AuthService } from 'src/app/_services/auth.service';
import { UserService } from 'src/app/_services/user.service';
import { AlertifyService } from 'src/app/_services/Alertify.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {

  @Input() user: User;
  constructor(private authService: AuthService, private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  sendLike(Id: number) {
    this.userService.sendLike(this.authService.decodedToken.nameid, Id).subscribe(data => {
      this.alertify.success('You have liked: ' + this.user.knownAs);
    }, error => {
        this.alertify.error(error);
    });
  }

}
