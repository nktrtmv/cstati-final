-- +goose Up
-- +goose StatementBegin
CREATE TABLE Users
(
    chat_id           TEXT,
    login             TEXT      NOT NULL,
    fullname          TEXT,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    is_deleted        BOOLEAN   NOT NULL DEFAULT FALSE,
    PRIMARY KEY (chat_id)
);

CREATE TABLE Events
(
    id           TEXT    NOT NULL,
    chat_id      TEXT,
    name         TEXT    NOT NULL,
    is_completed BOOLEAN NOT NULL DEFAULT FALSE,
    PRIMARY KEY (id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd