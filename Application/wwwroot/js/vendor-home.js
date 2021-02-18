VendorHomePage = (urls) => new VendorHome(urls);


class VendorHome {
    _urls;
    _modal;

    constructor(urls) {
        this._urls = urls;

        this.OpenQuoteModal = this.OpenQuoteModal.bind(this);
        this.RegisterModalEvents = this.RegisterModalEvents.bind(this);
        this.CreateResponse = this.CreateResponse.bind(this);

        this._modal = new tingle.modal({
            onOpen: this.RegisterModalEvents
        })
        this.RegisterEvents();
    }


    RegisterEvents() {
        document.querySelectorAll('[data-quote-btn]').forEach(e => {
            e.addEventListener('click', (t) => {
                const quoteID = parseInt(t.target.getAttribute('data-quote-btn'));
                this.OpenQuoteModal(quoteID);
            });
        });
    }

    RegisterModalEvents() {
        const sendBtn = document.querySelector(`[data-new-res-btn]`)
        //
        if (sendBtn != null)
            sendBtn.addEventListener('click', this.CreateResponse);
    }

    async OpenQuoteModal(quoteID) {
        const res = await MakeRequest(this._urls.quoteResponseModal, "POST", { QuoteID: quoteID });

        if (res.success) {
            this._modal.setContent(res.data);
            this._modal.open();
        } else {
            throw "Failed to load modal response partial... check the logs...that we dont event have lol";
        }
    }

    async CreateResponse() {
        const formData = Array.from(document.querySelectorAll('[data-form-for="new-response"] [data-name]')).reduce((v, e) => {
            v[e.getAttribute('data-name')] = e.value;
            return v;
        }, {});
        const res = await MakeRequest(this._urls.quoteResonseCreate, "POST", formData);

        if (res.success) {
            // I Cba updating the dom so this will close
            // and when it reopens it will be there
            this._modal.close();
        } else {
            throw "Failed to create new quote response";
        }
    }
}