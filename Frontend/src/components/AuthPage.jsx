import { Link } from "react-router-dom";
import React from "react";
import axios from "axios";
import { useState } from "react";
import Modal from "./Modal";

export default function AuthPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [modal, setModal] = useState(false);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const response = await axios.post(
      "http://localhost:5300/api/Auth",
      {
        login: username,
        password: password,
      },
      { withCredentials: true }
    );

    if (response.status === 200) {
      setModal(true);
      // navigate("/main");
    }
  };
  return (
    <main className="authPage">
      <section className="authorisation">
        <p className="auth">Авторизация</p>
        <form id="loginform" onSubmit={handleSubmit}>
          <div className="logininput">
            <input
              onChange={(e) => setUsername(e.target.value)}
              type="text"
              className="login"
              placeholder="Login"
              value={username}
            />
            <input
              onChange={(e) => setPassword(e.target.value)}
              type="password"
              className="password"
              placeholder="Password"
              value={password}
            />
          </div>
          <input className="signIn" type="submit" value={"Sign In"}></input>
          <Link to="/registration">
            <button className="reg">Registration</button>
          </Link>
          {modal ? (
            <Modal>
              <h1>Вы успешно вошли в систему</h1>
              <div className="ok">
                <Link to="/main">
                  <button
                    onClick={() => setModal(false)}
                    className="cancelmodal"
                  >
                    Ок
                  </button>
                </Link>
              </div>
            </Modal>
          ) : (
            <p></p>
          )}
        </form>
      </section>
    </main>
  );
}
