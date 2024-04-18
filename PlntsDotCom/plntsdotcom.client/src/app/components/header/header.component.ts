import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  dialogVisible: boolean = false;
  searchInput: string = '';

  constructor(private router: Router) {}

  navigateToRoot() {
    this.router.navigate(['/']);
  }

  openDialog() {
    this.dialogVisible = true;
    console.log('open dialog');
  }

  closeDialog() {
    this.dialogVisible = false;
  }

  onSearch() {
    if (this.searchInput.trim() !== '') {
      this.router.navigate(['/search-results'], { queryParams: { query: this.searchInput } });
    }
    this.closeDialog();
  }

}
