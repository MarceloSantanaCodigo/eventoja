import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/Models/Usuario';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-usuario-admin',
  templateUrl: './usuario-admin.component.html',
  styleUrls: ['./usuario-admin.component.scss']
})
export class UsuarioAdminComponent implements OnInit {


  public usuarioLogado: Usuario = null as any;
  public usuarios: Usuario[] = [];

  constructor(private usuarioService: UsuarioService,private router: Router) {}
  ngOnInit(): void {
    const nomeLocal = this.usuarioService.usuarioLogado;
    if (nomeLocal == null) {
      this.router.navigate(["/login"])

    } else {
      this.usuarioLogado = this.usuarioService.usuarioLogado;
      this.BuscarTodos();
    }
  }

  async BuscarTodos() {
    const usuarioApi =await this.usuarioService.BuscarTodos();
    this.usuarios = usuarioApi || [];
  }

  limpar() {
   this.usuarioService.Deslogar();
    this.usuarios = [];
    this.router.navigate(["/login"])
  }
}
