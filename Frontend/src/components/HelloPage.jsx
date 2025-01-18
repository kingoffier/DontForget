import logo from "../assets/Ellipse.svg";
import { Link } from "react-router-dom";
import React from "react";

export default function HelloPage() {
  return (
    <main className="helloPage">
      <section className="splashscreen">
        <section className="left">
          <p className="name">Don’t Forget</p>
          <section className="imageinslogan">
            <p className="slogan">Be organized</p>
            <img src={logo} alt="Ellipse" />
          </section>
        </section>
        <section className="right">
          <Link to='/authorisation'><button>Authorize</button></Link>
          <Link to='/registration'><button>Registration</button></Link>
        </section>
      </section>
    </main>
  );
}
