QuoteModal = (urls) => new QuoteResponder(urls);

class QuoteResponder {
    _urls;
    _modal;

    constructor(urls) {

        this._urls = urls;

        this.OpenQuoteModal = this.OpenQuoteModal.bind(this);
        this.RegisterModalEvents = this.RegisterModalEvents.bind(this);
        this.SendResponse = this.SendResponse.bind(this);        

        this.quoteID = 0;

        this._modal = new tingle.modal({
            onOpen: this.RegisterModalEvents
        });
        this.RegisterEvents();
    }

    RegisterEvents() {
        document.querySelectorAll('[data-responder-btn]').forEach(e => {
            e.addEventListener('click', (t) => {
                this.quoteID = parseInt(t.target.getAttribute('data-responder-btn'));
                this.OpenQuoteModal(this.quoteID);
            });
        });
    }

    RegisterModalEvents() {
        const approveBtn = document.querySelector('[data-approve-btn]');
        const rejectBtn = document.querySelector('[data-reject-btn]');
        if (approveBtn != null) {
            approveBtn.addEventListener('click', this.SendResponse, false);
            approveBtn.myParam = true;
        }
        if (rejectBtn != null) {
            rejectBtn.addEventListener('click', this.SendResponse, false);
            rejectBtn.myParam = false;
        }
    }

    async OpenQuoteModal(quoteID) {
        const res = await MakeRequest(this._urls.quoteResponderModal, "POST", { QuoteID: quoteID });
        if (res.success) {
            this._modal.setContent(res.data);
            this._modal.open();
        } else {
            throw "Failed to load modal responder partial.";
        }
    }

    async SendResponse(evt) {

        let isApproved = evt.currentTarget.myParam;       
        const res = await MakeRequest(this._urls.respondToQuote, "POST", { QuoteID: this.quoteID, IsApproved: isApproved });

        if (res.success) {
            this._modal.close();
            location.reload();
        } else {
            throw "Failed to create new quote response.";
        }
    }
}