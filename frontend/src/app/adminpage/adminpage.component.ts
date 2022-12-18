import {Component, OnInit} from "@angular/core";
import {HttpService} from "../../services/http.service";
import {Option} from "./andminoption/OptionDto";
import {FormControl, Validators} from "@angular/forms";
import {ThemePalette} from "@angular/material/core";
import {Router} from "@angular/router";


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.scss']
})

export class AdminpageComponent implements OnInit {
  links = [{link: '/adminpage/adminitem', name: 'Item'}, {link: '/adminpage/adminoptiongroup', name: 'Option group'},
    {link: '/adminpage/admincategory', name: 'Category'}, {link: '/adminpage/adminoption', name: 'Option'}];
  activeLink = this.links[0];

  constructor(private router: Router) {
    if(this.router.url == '/adminpage'){
      this.router.navigate([this.activeLink.link]);
    }
    router.events.subscribe((url: any) => {
        if(url.url == '/adminpage'){
          this.activeLink = this.links[0];
          this.router.navigate([this.activeLink.link])
        }
      }
    );
  }

  ngOnInit(): void {
  }

}
