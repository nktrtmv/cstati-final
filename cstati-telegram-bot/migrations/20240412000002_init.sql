-- +goose Up
-- +goose StatementBegin
CREATE TABLE UsersEvents
(
    event_id       TEXT,
    login          TEXT    NOT NULL,
    payment_status INTEGER NOT NULL DEFAULT 0,
    PRIMARY KEY (login)
);

-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd