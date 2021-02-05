LoginPage = (urls) => new Login(urls);


class Login {
    _loginButtonTag = "data-login-btn";
    _loginExternal = "external";
    _loginInternal = "internal";
    _dataTabWrapper = "data-tab-for";
    _dataTabButton = "data-btn-for";

    constructor(urls) {
        this._urls = urls;

        this.OnTabClick = this.OnTabClick.bind(this);
        this.OnLoginBtnClick = this.OnLoginBtnClick.bind(this);

        this.RegisterEvents();
    }

    RegisterEvents() {
        document.querySelectorAll(`[${this._loginButtonTag}]`).forEach(f => f.addEventListener('click', this.OnLoginBtnClick));
        document.querySelectorAll(`[${this._dataTabButton}]`).forEach(f => f.addEventListener('click', this.OnTabClick));
    }

    async OnLoginBtnClick(e) {
        const loginType = e.target.getAttribute(this._loginButtonTag);
        const loginUrl = loginType === this._loginInternal ? this._urls.internalAuth : this._urls.externalAuth;
        const email = document.querySelector(`[${this._dataTabWrapper}="${loginType}"] [name="email"]`).value;

        let res = await MakeRequest(loginUrl, "POST", { Email: email });
        if (res.success) {
            location.href = loginType === this._loginInternal ? "/Home" : "/VendorHome";
        }
    }

    OnTabClick(e) {
        const tabType = e.target.getAttribute(this._dataTabButton);

        document.querySelectorAll(`[${this._dataTabWrapper}]`).forEach(f => f.classList.add('d-none'));
        document.querySelectorAll(`[${this._dataTabButton}]`).forEach(f => f.classList.remove('active'));
        document.querySelector(`[${this._dataTabWrapper}="${tabType}"]`).classList.toggle('d-none', false);
        e.target.classList.add('active');
    }
}