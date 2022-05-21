import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/Models/Usuario';
import { UsuarioService } from './usuario.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(private usuarioService: UsuarioService, private router: Router) {}
  ngOnInit(): void {
    if (this.usuarioService.usuarioLogado != null) {
      this.router.navigate(['/painel']);
    }
  }
}
